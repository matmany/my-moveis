using System.ComponentModel;

namespace MyMovieApi.Core.Enums;

public enum UserEnum
{
    [Description("Email ou senha incorretos.")]
    EmailOrPasswordIncorret,
    [Description("Usuário não encontrado.")]
    NotFound,
    [Description("Filme adicionado ao usuário.")]
    MovieAdded
}