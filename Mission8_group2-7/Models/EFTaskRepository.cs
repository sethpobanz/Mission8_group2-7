namespace Mission8_group2_7.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private Mission8ApplicationContext _context;

        public EFTaskRepository(Mission8ApplicationContext temp)
        {
            _context = temp;
        }

        public List<TaskModel> Tasks => _context.Tasks.ToList();

        public void addTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void updateTask(TaskModel task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

    }
}
