namespace Services.Interfaces;

public interface IService<T> where T : class
{
    List<T> FindAll();
}
