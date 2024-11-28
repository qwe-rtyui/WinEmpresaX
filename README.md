# WinEmpresaX

Uma aplicação desktop desenvolvida em **C# com Windows Forms** para a gestão de produtos, utilizando **PostgreSQL** como banco de dados.

---

## 📋 Funcionalidades
- Listar produtos no banco de dados.
- Adicionar novos (clientes, produtos, vendas).
- Editar (clientes, produtos) existentes.
- Remover (clientes, produtos).
- Interface moderna e estilizada com funcionalidades úteis como validação de campos.

## 🛠️ Tecnologias Utilizadas
- **C#** (WinForms)
- **PostgreSQL** (Banco de Dados)
- **Npgsql** (Driver para conexão com PostgreSQL)
- **Windows Forms** (Interface gráfica)

---

## 🚀 Configuração do Ambiente

### Requisitos
- PostgreSQL configurado e em execução.
- Visual Studio ou Visual Studio Code configurado para desenvolvimento em C#.
- Ferramenta de gerenciamento de banco de dados (como pgAdmin ou DBeaver) para importar o script SQL.

### Configurando o Banco de Dados
1. Crie um banco de dados no PostgreSQL com o nome: `KyotoDesk`.
2. Execute o script SQL (`database.sql`) que se encontra na pasta `/sql` para criar as tabelas e procedures necessárias.

### Configuração do Código
1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/winforms-kyoto-desk.git
    cd winforms-kyoto-desk
2. Abra o projeto em seu editor de preferência.
3. Atualize a string de conexão no arquivo DatabaseConnection.cs (variável _connectionString) com suas credenciais do PostgreSQL:

    ```
    private string _connectionString = "Host=localhost;Port=5432;Username=seu-usuario;Password=sua-senha;Database=KyotoDesk";
    ```

## ▶️ Executando a Aplicação
Compile o projeto.
Execute a aplicação diretamente no Visual Studio ou no terminal:
    ```
    dotnet run
    ```
## 📂 Estrutura do Projeto

    ```
    |-- /src
    |   |-- /WinFormsKyotoDesk
    |       |-- Data        # Camada de acesso a dados
    |       |-- UI          # Estilos e controles da interface
    |       |-- Program.cs  # Ponto de entrada da aplicação
    |-- /sql
    |   |-- database.sql    # Script SQL para criação do banco de dados
    |-- README.md           # Documentação do projeto
    
## ⚙️ Estrutura do Banco de Dados
### Tabelas
- products: Contém as informações de cada produto.
- id (int): Identificador único.
- nome (varchar): Nome do produto.
- descricao (text): Descrição do produto.
- preco (decimal): Preço do produto.
- estoque (int): Quantidade disponível em estoque.
### Procedures & Functions
- sp_list_product: Retorna todos os produtos cadastrados.
- sp_insert_product: Insere um novo produto.
- sp_update_product: Atualiza informações de um produto existente.
- sp_remove_product: Remove um produto pelo ID.
  
- sp_list_client: Retorna todos os clientes cadastrados.
- sp_insert_client: Insere um novo client.
- sp_update_client: Atualiza informações de um client existente.
- sp_remove_client: Remove um client pelo ID, Etc.

---

<h2>📸 Capturas de Tela</h2>

<div style="display:flex;">
    <img src="https://github.com/qwe-rtyui/WinEmpresaX/blob/main/img/Clist.png" style="heigth:500px; width:550px">

- Lista dos clientes adicionados.
- Botões p/ (Adicionar, Editar e Remover) clientes.
- Interface moderna e estilizada com funcionalidades úteis como validação de campos.
</div>

--

<div style="display:flex;">    
    <img src="https://github.com/qwe-rtyui/WinEmpresaX/blob/main/img/Vadd.png" style="heigth:500px; width:550px"> 
    
- Selecionar cliente para realizar uma venda.
- Selecionar o produto, a quantidade e adicionar na lista de venda.
</div>

--

<div style="display:flex;">  
    <img src="https://github.com/qwe-rtyui/WinEmpresaX/blob/main/img/Rvendas.png" style="heigth:500px; width:550px">
        
- Relatório de (vendas, estoque e cliente).
- Selecionar a venda para saber mais detalhe da mesma.
</div>

--

## 👨‍💻 Contribuição
Sinta-se à vontade para abrir Issues ou enviar Pull Requests para melhorias ou correções. 💡

## 📝 Licença
Este projeto está sob a licença MIT. Consulte o arquivo LICENSE para mais informações.

## 📞 Contato
- **Email:** kesleyjuan.dev@gmail.com


