using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.Service
{
    public class AutenticacaoService
    {
        private readonly Context _ctx;
        public AutenticacaoService(Context ctx)
        {
            _ctx = ctx;
        }

        public LoginResponse GerarTokenporId(LoginRequest request)
        {
            var usuario = _ctx.tabUsuario.FirstOrDefault(x => x.email == request.email && x.senha == request.password);
            if (usuario == null || usuario.tipoUsuarioCodigo == 0)
            {
                return null;
            }
            usuario.ultimoAcesso = DateTime.Now;
            _ctx.tabUsuario.Update(usuario);
            _ctx.SaveChanges();
                return new LoginResponse
                {
                    token = GeraTokenJwt(usuario),
                    tipo = usuario.tipoUsuarioCodigo,
                    codigo = usuario.codigo,
                    nome = usuario.nome,
                    unidade = usuario.unidadeCodigo,
                    avatar = string.IsNullOrEmpty(usuario.foto) ? "https://api.dicebear.com/8.x/bottts-neutral/svg?seed=Max" : usuario.foto
                };
        }
        private string GeraTokenJwt(TabUsuario usuario)
        {
            var issuer = "dose";
            var audience = "dose";
            var key = "c013239a-5e89-4749-b0bb-07fe4d21710d";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("tipo", usuario.tipoUsuarioCodigo.ToString()),
                new Claim("usuarioCodigo", usuario.codigo.ToString()),
                new Claim("unidadeCodigo",usuario.unidadeCodigo.ToString())
            };

            var token = new JwtSecurityToken(issuer: issuer, claims: claims, audience: audience, expires: DateTime.Now.AddMinutes(100), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
