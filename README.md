# Validador de CNPJ Alfanumérico

Projeto desenvolvido para validar CNPJs alfanuméricos conforme as novas regras da Receita Federal.

<img width="1919" height="909" alt="image" src="https://github.com/user-attachments/assets/d6354434-636e-48f2-ba22-ae0fb91af042" />

## Tecnologias

- React
- JavaScript
- .NET 8
- ASP.NET Core Web API

## Funcionalidades

- Validação de CNPJ alfanumérico com novas regras da SEFAZ
- API REST
- Interface Web

## Como Executar o Projeto

### Clonar o repositório

```bash
git clone https://github.com/paulowagnerdev/validated-cnpj.git
```

### Executar a API

Acesse a pasta da API:

```bash
cd backend/ValidadorCnpj.Api
```

Restaure os pacotes:

```bash
dotnet restore
```

Execute a aplicação:

```bash
dotnet run
```

### Executar o Front-end

Em outro terminal, acesse a pasta do front-end:

```bash
cd frontend
```

Instale as dependências:

```bash
npm install
```

Execute a aplicação:

```bash
npm run dev
```

A aplicação estará disponível em:

```text
http://localhost:5173
```

## Estrutura do Projeto

```text
backend/
├── ValidadorCnpj.Api
├── ValidadorCnpj.Service

frontend/
├── src
├── public
```

## Autor

Paulo Wagner
