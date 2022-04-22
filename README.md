# MoreResultsAPI

API para Cadastro de Usuários.
Leitura, Inserção, Atualização e Exclusão em BD;
API utilizando conceitos de MVC e SOLID;
Máscaras de inputs (Telefone, CPF e CEP);
Conexão com a API BuscaCEP para preenchimento automático de endereço;
Validação de CPF;
Máscara de senha com possibilidade de visualização na tela de Edição.

Características da API:
FrameWork: .Net 6.0.
ORM: EntityFramework Core 7.0.
FrontEnd: HTML, JavaScript, JQuery, Vue.JS.
Página HTML: View/Index.html
Scripts de Criação de BD: Migrations/20220421225052_CreateInitial
Utilizando Node.JS para resolver problema CORS (Google Chrome)

Observações: Para efetuar a criação do banco de dados, devem ser realizados os procedimentos Entity Framework Core. Segue o passo-a-passo:
1 - Alterar a ConnectionString para o endereço do seu BD, localizada em appsettings.json
2 - Abrir o Package Manager Console e digitar:
dotnet ef migrations add CreateInitial

Este comando executará o script em Migrations e criará um BD com a tabela Usuários.

Ajustes necessário para a próximas versões:
1 - Validação de e-mail;
2 - Biblioteca de envio de e-mail de confirmação de cadastro;
3 - Melhorar alertas de retorno de erros;
4 - Implementar modal personalizado para Erros, Alertas e Confirmações.
5 - Adicionar novas colunas para o usuário (sexo, celular, RG, foto, entre outros)

Aberto a sugestões nos comentários.

Vitor Henrique Vianna Reis
vitor_hvr@outlook.com
(21)99479-7667
