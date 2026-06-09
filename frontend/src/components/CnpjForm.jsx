import { useState } from "react";
import { processCnpj } from "../services/api";
import { ACTIONS } from "../utils/constants";
import InputMask from "react-input-mask";
import '.././App.css'

export default function CnpjForm() {

    const [cnpj, setCnpj] = useState("");
    const [result, setResult] = useState("");
    const [loading, setLoading] = useState(false);
    const [action, setAction] = useState(ACTIONS.validar);
    const [error, setError] = useState(false);

    async function handleSubmit(e) {
        e.preventDefault();

        if (!cnpj) {
            setResult("Digite um CNPJ");
            return;
        }

        setLoading(true);
        setResult("");

        try {

            const response = await processCnpj(cnpj, action);

            if (response.isValido) {
                setResult("CNPJ Válido");
                setError(false);
            } else {
                setResult(response.mensagem);
                setError(true);
            }

        } catch (error) {
            alert(error);
            setResult("Erro ao conectar com a API");
        } finally {
            setLoading(false);
        }


    }

    function formatCnpjAlfa(value) {

        const cleaned = value
            .replace(/[^A-Za-z0-9]/g, "")
            .toUpperCase()
            .slice(0, 14);

        let formatted = cleaned;

        if (cleaned.length > 2) {
            formatted = cleaned.slice(0, 2) + "." + cleaned.slice(2);
        }

        if (cleaned.length > 5) {
            formatted =
                cleaned.slice(0, 2) + "." +
                cleaned.slice(2, 5) + "." +
                cleaned.slice(5);
        }

        if (cleaned.length > 8) {
            formatted =
                cleaned.slice(0, 2) + "." +
                cleaned.slice(2, 5) + "." +
                cleaned.slice(5, 8) + "/" +
                cleaned.slice(8);
        }

        if (cleaned.length > 12) {
            formatted =
                cleaned.slice(0, 2) + "." +
                cleaned.slice(2, 5) + "." +
                cleaned.slice(5, 8) + "/" +
                cleaned.slice(8, 12) + "-" +
                cleaned.slice(12);
        }

        return formatted;
    }

    return (
        <div className="container">
            <div className="card">
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
                        {loading ? (
                            <>
                                <span className="spinner"></span>
                                Processando...
                            </>
                        ) : (
                            "Executar"
                        )}
                    </button>
                </form>

                {result && (
                    <div
                        className={`result ${!error
                            ? "success"
                            : "error"
                            }`}
                    >
                        {result}
                    </div>
                )}
            </div>
        </div>
    );
}