using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

namespace TodoApp
{
    class TodoManager
    {        
        private readonly string connectionString;

        public TodoManager(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void AddTodoItem(string title)
        {
            TodoItem newTodoItem = new TodoItem() { Title = title };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO TODO (Title, isDone) values (@Title, 0)", newTodoItem);
            }
        }
        public void SetDeadline()
        {

        }
        public void UpdateStatus(int todoId)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("UPDATE TODO SET isDone = 1 WHERE Id = " + todoId);
            }
        }
        public void RemoveTodoItem(int todoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("DELETE FROM TODO WHERE Id = @Id", new { Id = todoId } );
            }
        }        
        public IEnumerable<TodoItem> GetTodos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<TodoItem>("SELECT Title, isDone, Id FROM TODO ORDER BY Id");
            }
        }
    }
}