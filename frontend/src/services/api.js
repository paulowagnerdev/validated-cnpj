const BASE_URL = "https://localhost:7173/api/Cnpj";

export async function processCnpj(cnpj, action) {

  cnpj = cnpj.replace(/[^A-Za-z0-9]/g, "");

  try {
    const response = await fetch(`${BASE_URL}/${action.toLowerCase()}/${cnpj}`);

    return response.json();

  } catch (error) {
    throw error;
  }
}

