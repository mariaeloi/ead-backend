namespace Domain.Enum;

public class EntityEnum
{
    private EntityEnum(string value) { Value = value; }

    public string Value { get; private set; }

    public static EntityEnum User { get { return new EntityEnum("Usuário"); } }
    public static EntityEnum Course { get { return new EntityEnum("Curso"); } }
    public static EntityEnum Lesson { get { return new EntityEnum("Aula"); } }
}