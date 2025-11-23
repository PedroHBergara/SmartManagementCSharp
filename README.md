# SmartManagement API

## 📋 Sobre o Projeto

SmartManagement é uma API REST desenvolvida em C# para gerenciamento de tarefas pessoais e profissionais. O sistema permite criar, listar, atualizar e excluir tarefas de forma simples e eficiente.

## 👥 Desenvolvedores

- **Pedro Henrique Bergara**
- **Henrique Izzi**

## 🎯 Objetivo

Facilitar o gerenciamento de tarefas pessoais e profissionais através de uma API robusta e fácil de usar, permitindo organização e acompanhamento de atividades do dia a dia.

## 🚀 Tecnologias Utilizadas

- C# / .NET
- ASP.NET Core
- Entity Framework Core
- Swagger / OpenAPI
- SQL Server / Oracle

## 📡 Endpoints da API

### Base URL
```
https://localhost:5000/tasks
```

### Tarefas (Tasks)

#### 📝 POST - Criar nova tarefa
```http
POST /tasks
Content-Type: application/json
```

**Body:**
```json
{
  "title": "video demonstrativo para gs2",
  "description": "video referente a entrega da gs test 2",
  "status": "PENDING",
  "type": "PERSONAL",
  "userId":12,
  "dueDate": "2025-12-22T12:00:00"
}

```

**Response (201 Created):**
```json
{
  "id": 1,
  "titulo": "Reunião com cliente",
  "descricao": "Discutir requisitos do projeto",
  "dataVencimento": "2024-12-31T14:00:00",
  "prioridade": "Alta",
  "status": "Pendente",
  "dataCriacao": "2024-11-23T10:30:00"
}
```

---

#### 📖 GET - Listar todas as tarefas
```http
GET /tasks
```

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "titulo": "Reunião com cliente",
    "descricao": "Discutir requisitos do projeto",
    "dataVencimento": "2024-12-31T14:00:00",
    "prioridade": "Alta",
    "status": "Pendente",
    "dataCriacao": "2024-11-23T10:30:00"
  },
  {
    "id": 2,
    "titulo": "Revisar código",
    "descricao": "Code review do PR #123",
    "dataVencimento": "2024-11-25T16:00:00",
    "prioridade": "Média",
    "status": "Em Andamento",
    "dataCriacao": "2024-11-23T11:00:00"
  }
]
```

---

#### 🔍 GET - Buscar tarefa por ID
```http
GET /tasks/{id}
```

**Exemplo:**
```http
GET /tasks/1
```

**Response (200 OK):**
```json
{
  "id": 1,
  "titulo": "Reunião com cliente",
  "descricao": "Discutir requisitos do projeto",
  "dataVencimento": "2024-12-31T14:00:00",
  "prioridade": "Alta",
  "status": "Pendente",
  "dataCriacao": "2024-11-23T10:30:00"
}
```

---

#### ✏️ PUT - Atualizar tarefa
```http
PUT /tasks/{id}
Content-Type: application/json
```

**Exemplo:**
```http
PUT /tasks/1
```

**Body:**
```json
{
  "id": 1,
  "titulo": "Reunião com cliente - Atualizada",
  "descricao": "Discutir requisitos e cronograma do projeto",
  "dataVencimento": "2024-12-31T15:00:00",
  "prioridade": "Alta",
  "status": "Em Andamento"
}
```

**Response (200 OK):**
```json
{
  "id": 1,
  "titulo": "Reunião com cliente - Atualizada",
  "descricao": "Discutir requisitos e cronograma do projeto",
  "dataVencimento": "2024-12-31T15:00:00",
  "prioridade": "Alta",
  "status": "Em Andamento",
  "dataCriacao": "2024-11-23T10:30:00"
}
```

---

#### 🗑️ DELETE - Excluir tarefa
```http
DELETE /tasks/{id}
```

**Exemplo:**
```http
DELETE /tasks/1
```

**Response (204 No Content)**

---

## 📚 Documentação Swagger

A documentação interativa da API está disponível através do Swagger UI:

```
https://localhost:{porta}/swagger
```

Através do Swagger você pode:
- Visualizar todos os endpoints disponíveis
- Testar as requisições diretamente pela interface
- Ver os modelos de dados (schemas)
- Verificar os códigos de resposta HTTP

## 🔧 Como Executar o Projeto

### Pré-requisitos

- .NET SDK 6.0 ou superior
- SQL Server ou Oracle Database
- Visual Studio 2022 ou VS Code

### Passos

1. Clone o repositório
```bash
git clone https://github.com/PedroHBergara/SmartManagementCSharp.git
cd SmartManagementCSharp
```

2. Configure a string de conexão no `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "sua-string-de-conexao"
  }
}
```

3. Execute as migrations
```bash
dotnet ef database update
```

4. Execute o projeto
```bash
dotnet run
```

5. Acesse o Swagger em `https://localhost:{porta}/swagger`

## 📝 Status Codes

| Código | Descrição |
|--------|-----------|
| 200 | OK - Requisição bem-sucedida |
| 201 | Created - Recurso criado com sucesso |
| 204 | No Content - Recurso deletado com sucesso |
| 400 | Bad Request - Dados inválidos |
| 404 | Not Found - Recurso não encontrado |
| 500 | Internal Server Error - Erro no servidor |

## 📄 Licença

Este projeto foi desenvolvido para fins educacionais.

---

Desenvolvido com ❤️ por Pedro Henrique Bergara e Henrique Izzi
