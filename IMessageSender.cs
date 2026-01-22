namespace M3;

public interface IMessageSender
{
    void SendMessage(string message, List<Employee> employees);
}
