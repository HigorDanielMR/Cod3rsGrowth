using System.ComponentModel;

public static class ObterEnums
{
    public static List<string> ObterDescricaoEnums<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T))
                   .Cast<T>()
                   .Select(e => ObterDescricaoEnum(e))
                   .ToList();
    }

    private static string ObterDescricaoEnum<T>(T valorEnum) where T : Enum
    {
        var campoDeInformacoes = valorEnum.GetType().GetField(valorEnum.ToString());
        var descricaoAtributos = (DescriptionAttribute[])campoDeInformacoes.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return descricaoAtributos.Length > 0 ? descricaoAtributos[0].Description : valorEnum.ToString();
    }
}
