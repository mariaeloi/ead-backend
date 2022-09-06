namespace Domain.Enum;

public class ActionEnum
{
    private ActionEnum(string value) { Value = value; }

    public string Value { get; private set; }

    public static ActionEnum Create   { get { return new ActionEnum("Criação"); } }
    public static ActionEnum Update   { get { return new ActionEnum("Atualização"); } }
    public static ActionEnum Delete   { get { return new ActionEnum("Remoção"); } }
    public static ActionEnum Login    { get { return new ActionEnum("Login"); } }
    public static ActionEnum Logout   { get { return new ActionEnum("Logout"); } }
}