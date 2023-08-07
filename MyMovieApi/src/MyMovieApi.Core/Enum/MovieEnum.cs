using System.ComponentModel;

namespace MyMovieApi.Core.Enums;

public enum MovieEnum
{
    [Description("Filme criado.")]
    Created,
    [Description("Filme Atualizado")]
    Updated,
    [Description("Email ou senha incorretos")]
    EmailOrPasswordIncorret,
    [Description("Filme não encontrado.")]
    NotFound,
}