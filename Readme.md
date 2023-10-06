# Json Web Token Authentication API
O projeto se resume em uma API desenvolvida como parte de um processo de aprendizado, com o objetivo de aprimorar a compreensão e prática dos conceitos de autenticação e autorização baseados em Tokens JWT (JSON Web Tokens).
A API foi construída utilizando a linguagem C# juntamente com a tecnologia ASP.NET e com o uso do Entity Framework. O projeto segue práticas e padrões de segurança para garantir a confiabilidade e a integridade dos dados.

# Funcionalidades Principais
### Autenticação via Tokens JWT: 
- A API implementa um sistema de autenticação baseado em tokens JWT. Isso permite que os usuários se autentiquem fornecendo suas credenciais e recebam um token JWT válido, que pode ser usado para acessar rotas e recursos protegidos.
### Autorização de Rotas e Recursos: 
- Com base nos tokens JWT válidos, a API oferece suporte à autorização de rotas e recursos. Dependendo dos privilégios do usuário, certas rotas e recursos podem ser acessados ou restritos, garantindo que apenas usuários autenticados e autorizados tenham acesso a determinadas funcionalidades.
### Endpoints Restritos: 
- A API inclui endpoints específicos que requerem autenticação e/ou autorização para serem acessados. Esses endpoints podem fornecer funcionalidades adicionais ou recursos sensíveis que estão disponíveis apenas para usuários autenticados e autorizados.

# Como executar o projeto
```bash
# Clonar repositório
git clone https://github.com/esdraslimaf/JWTokenAuthAPI.git
```


# Demonstração do projeto por imagens.
### Obs: Para fins de praticidade, optou-se por utilizar uma classe estática para representar o banco de dados contendo os usuários cadastrados.
O método abaixo deve buscar um usuário específico no banco de dados desde que ele esteja cadastrado.

![image](https://github.com/esdraslimaf/JWTokenAuthAPI/assets/101669187/4d68eca7-c646-4364-ae20-55ed252d5210)

Abaixo no "Postman API Platform" temos o "Erro 404 - Not Found" ao buscar um usuário, pois no JSON foram repassados dados inexistentes no "banco de dados".

![image](https://github.com/esdraslimaf/JWTokenAuthAPI/assets/101669187/d82f8e91-7659-402b-900a-e0976ccc72e3)

Abaixo, estamos realizando uma autenticação com um usuário existente, o servidor autentica as credenciais do usuário e gera um token de autenticação, conhecido como JWT (JSON Web Token).
Esse token JWT contém as informações necessárias para identificar o usuário de forma única, como o ID do usuário, o nome, o papel ou função atribuído a ele e outras informações relevantes.

![image](https://github.com/esdraslimaf/JWTokenAuthAPI/assets/101669187/3697f539-880c-4807-a5a4-9ea3d3f1dfa7)

Abaixo, utilizando o TOKEN gerado, acesamos uma rota disponível para o usuário(Rota para Funcionários), e logo em seguida tentamos acessar uma outra rota(Rota para Chefe) que deve ser inacessível para ele devido a falta de previlégios.

![image](https://github.com/esdraslimaf/JWTokenAuthAPI/assets/101669187/887ae753-6c25-4edb-acb4-0eb74c9e81ca)


Para que seja possível acessar a rota que foi negada anteriormente(Rota para Chefe) temos que realizar uma autenticação com o usuário que possui tal previlégio. Ao autenticar com sucesso esse novo usuário, será gerado um novo token que contenha as permissões apropriadas para acessar a rota desejada. Esse novo token será utilizado para autenticar o usuário e garantir o acesso à rota que anteriormente estava inacessível devido à falta de privilégios.

![image](https://github.com/esdraslimaf/JWTokenAuthAPI/assets/101669187/7cf391b9-8e6b-4213-a933-03258c4204b2)



# Autor

Esdras Lima

https://www.linkedin.com/in/esdrasdev/
