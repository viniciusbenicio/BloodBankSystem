# 🩸 Blood Bank System API

API desenvolvida em **ASP.NET Core 8**, utilizando **Entity Framework Core** e **SQL Server** para gerenciamento de um sistema de banco de sangue. O projeto segue princípios da **Arquitetura Limpa**, utilizando **InputModels** e **ViewModels** para separar modelos de entrada e saída de dados.

## ✅ Tecnologias e Ferramentas Utilizadas

* **ASP.NET Core 8**
* **Entity Framework Core**
* **SQL Server**
* **Arquitetura Limpa**

  * Separação de camadas: Core, Application, Infrastructure e API.
* **InputModels** e **ViewModels** para entrada e saída de dados.

## 🔧 Estrutura da API

A API possui endpoints para gerenciamento das seguintes entidades:

* **BloodStock** (`/api/bloodStocks`)
* **Donation** (`/api/donations`)
* **Donnor** (`/api/donors`)

Cada entidade possui operações de **CRUD** completas, utilizando padrões RESTful.

## 📦 Modelos de Dados

Os modelos são organizados da seguinte forma:

* `InputModels`: Modelos utilizados para entrada de dados.
* `ViewModels`: Modelos utilizados para retorno e exibição de dados.

## 🏗️ Funcionalidades Implementadas

* Operações CRUD para:

  * Estoque de sangue
  * Doações
  * Doadores
* Separação de responsabilidades utilizando a **Arquitetura Limpa**.
* Configuração inicial de banco de dados utilizando **Entity Framework Core**.

## 🚧 Funcionalidades Futuras

O projeto está em constante evolução, com as seguintes implementações previstas:

* ✅ **Unit of Work** para gestão de transações.
* ✅ **Padrão Repository** para abstração de acesso a dados.
* ✅ **CQRS** (Command Query Responsibility Segregation) para separação clara entre operações de leitura e escrita.
* ✅ **Testes Unitários** para garantir qualidade e confiabilidade do código.
* ✅ **FluentValidation** para validação fluente de modelos de entrada.
* ✅ **IEntityTypeConfiguration** para configuração das entidades via Fluent API no Entity Framework.
* ✅ **Integração com Serviços Cloud**: A escolha do provedor de cloud ainda será definida conforme as necessidades do projeto.

## 🏁 Como Executar

1. Clone o repositório:

```bash
https://github.com/viniciusbenicio/BloodBankSystem.API.git
```

2. Configure a string de conexão no arquivo `appsettings.json`:

```json
{
   "ConnectionStrings": {
   "DefaultConnection": "Server=localhost,1433;Database=BloodBankDB;User ID=sa;Password=Api@pass!; TrustServerCertificate=True"
 }
}
```

3. Execute as migrações do banco de dados:

```bash
dotnet ef database update
```

4. Inicie o projeto:

```bash
dotnet run
```

A API estará disponível em: `http://localhost:49578`.

## 📝 Documentação da API

A documentação da API está disponível via **Swagger** em:

```
http://localhost:49578/swagger
```

