const BASE_URL = "http://localhost:5000/api";

export async function processCnpj(cnpj) {
  const response = await fetch(`${BASE_URL}/cnpj`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ cnpj }),
  });

  if (!response.ok) {
    throw new Error("Erro na requisição");
  }

  return response.json();
}