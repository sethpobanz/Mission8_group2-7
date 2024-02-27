namespace Mission8_group2_7.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task task);
        public void UpdateTask(Task task);

    }
}
