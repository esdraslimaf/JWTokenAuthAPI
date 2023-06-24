using AuthApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user) //Retornando uma string, para retornar o token final
        {
            // Classe que vamos usar para gerar o token
            var tokenHandler = new JwtSecurityTokenHandler();

            // A linha de código em questão converte a string contida na propriedade "Settings.Secret" em uma sequência de bytes usando a codificação ASCII.
            // Isso é necessário porque as operações de criptografia e assinatura digital geralmente exigem que a chave seja representada como uma sequência de bytes.
            var key = Encoding.ASCII.GetBytes(Settings.Secret);


            //Abaixo vamos definir as informações do nosso token, através do TokenDescriptor
            //Define as informações do token, como expiração e credenciais de assinatura utilizadas para realizar a assinatura digital do token()       
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // O ClaimsIdentity recebe uma lista de Claims. 
                /* Claims são informações sobre os usuários que são incluídas no token de autenticação, como um JWT. O token com os claims é enviado ao servidor em cada solicitação do usuário. O servidor utiliza os claims para verificar as permissões do usuário e decidir se ele tem acesso aos recursos solicitados. */
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
                                                       }),

                Expires = DateTime.UtcNow.AddHours(8), //após 8 horas o token expira, e vamos precisar fazer um processo de "refresh token"

                // Agora vamos definir as credenciais de assinatura para o token. As credenciais são utilizadas para garantir a autenticidade e integridade do token.        
                // Representa as credenciais de assinatura utilizadas para assinar digitalmente o token. Neste caso, estamos utilizando new SymmetricSecurityKey(key) para criar uma chave simétrica a partir da sequência de bytes da chave secreta convertida. Em seguida, definimos o algoritmo de assinatura como SecurityAlgorithms.HmacSha256Signature, que usa o algoritmo HMAC-SHA256 para realizar a assinatura.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            /* No JWT, o SigningCredentials é como uma "assinatura" adicionada ao token. Ele garante que o token não tenha sido alterado de forma não autorizada. A assinatura verifica a integridade do token.

             O SigningCredentials usa uma chave ou certificado para gerar essa assinatura. É como um carimbo de autenticidade que permite ao servidor verificar se o token é legítimo.

             Portanto, o SigningCredentials não criptografa ou desencripta o token, mas adiciona uma assinatura digital para protegê-lo contra alterações não autorizadas e garantir a integridade do token. */ 




            // Gera o token com base no tokenDescriptor usando o tokenHandler
            var token = tokenHandler.CreateToken(tokenDescriptor); //Criou um objeto SecurityToken
          
            // Retorna o token como uma string
            return tokenHandler.WriteToken(token); //Escreve o SecurityToken em string
        }
    }
}
