import { useState } from "react";
import { processCnpj } from "../services/api";
import InputMask from "react-input-mask";
import '.././App.css'

export default function CnpjForm() {
    const [cnpj, setCnpj] = useState("");
    const [result, setResult] = useState("Teste");
    const [loading, setLoading] = useState(false);

    async function handleSubmit(e) {
        e.preventDefault();

        if (!cnpj) {
            setResult("Digite um CNPJ");
            return;
        }

        setLoading(true);
        setResult("");

        try {
            const data = await processCnpj(cnpj);

            if (data.success) {
                setResult(data.data);
            } else {
                setResult(data.message);
            }
        } catch (error) {
            setResult("Erro ao conectar com a API");
        } finally {
            setLoading(false);
        }


    }

    function formatCnpjAlfa(value) {

        let cleaned = value.replace(/[^a-zA-Z0-9]/g, "").toUpperCase();

        cleaned = cleaned.slice(0, 14);

        let formatted = cleaned;

        if (cleaned.length > 2) {
            formatted = cleaned.replace(/^(.{2})(.*)/, "$1.$2");
        }
        if (cleaned.length > 5) {
            formatted = formatted.replace(/^(.{6})(.*)/, "$1.$2");
        }
        if (cleaned.length > 8) {
            formatted = formatted.replace(/^(.{10})(.*)/, "$1/$2");
        }
        if (cleaned.length > 12) {
            formatted = formatted.replace(/^(.{15})(.*)/, "$1-$2");
        }

        return formatted;
    }

    return (
        <div className="container">
            <h2>Validador de CNPJ</h2>

            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Digite o CNPJ"
                    value={cnpj}
                    onChange={(e) => {
                        const masked = formatCnpjAlfa(e.target.value);
                        setCnpj(masked);
                    }}
                />

                <button type="submit" disabled={loading}>
                    {loading ? "Processando..." : "Executar"}
                </button>
            </form>
        </div>
    );
}