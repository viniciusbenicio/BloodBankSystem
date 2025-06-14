# 🩸 Blood Bank System API

API desenvolvida em **ASP.NET Core 8**, utilizando **Entity Framework Core** e **SQL Server** para gerenciamento de um sistema de banco de sangue. O projeto segue princípios da **Arquitetura Limpa**, separando responsabilidades em diferentes camadas e utilizando **InputModels** e **ViewModels** para entrada e saída de dados.

---

## ✅ Tecnologias e Ferramentas Utilizadas

* **ASP.NET Core 8**
* **Entity Framework Core**
* **SQL Server**
* **Arquitetura Limpa**

  * Camadas: `Core`, `Application`, `Infrastructure`, `API`
* **InputModels** e **ViewModels**
* **CQRS**
* **Padrão Repository**
* **Unit of Work**
* **FluentValidation**
* **Swagger**
* **Integração com API ViaCEP**

---

## 🔧 Estrutura da API

A API possui endpoints RESTful organizados para as seguintes entidades:

* **Donor** (`/api/donors`)
* **Donation** (`/api/donations`)
* **BloodStock** (`/api/bloodStocks`)

Cada entidade possui operações de **CRUD** completas, com validações e regras de negócio aplicadas.

---

## 📦 Modelos de Dados

* `InputModels`: usados para entrada de dados via API.
* `ViewModels`: utilizados para retornar dados formatados na resposta.

---

## ✅ Funcionalidades Implementadas

* Cadastro, edição, consulta e exclusão de:

  * Doadores
  * Doações
  * Estoque de sangue
* **Validações de Regras de Negócio**, como:

  * Impedir cadastro com e-mails duplicados
  * Menores de idade podem se cadastrar, mas **não** doar
  * Peso mínimo: **50kg**
  * Mulheres só podem doar a cada **90 dias**
  * Homens só podem doar a cada **60 dias**
  * Volume da doação entre **420ml e 470ml**
* Atualização automática do estoque de sangue após doação
* Consulta ao histórico de doações de cada doador
* Integração com **API ViaCEP** para preenchimento automático de endereço
* Aplicação do padrão **Repository**
* Separação de comandos e consultas usando **CQRS**
* Validações aplicadas via **FluentValidation**


## ▶️ Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/viniciusbenicio/BloodBankSystem.API.git
```

2. Configure a string de conexão no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=BloodBankDB;User ID=sa;Password=Api@pass!;TrustServerCertificate=True"
  }
}
```

3. Aplique as migrações do banco de dados:

```bash
dotnet ef database update
```

4. Execute o projeto:

```bash
dotnet run
```

A API estará disponível em: `http://localhost:49578`

---

## 📘 Documentação da API

Acesse via Swagger:

```
http://localhost:49578/swagger
```

---
