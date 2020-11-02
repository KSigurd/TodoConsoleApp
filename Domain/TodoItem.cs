using System;
namespace TodoApp
{
    class TodoItem
    {
        private string title;
        private bool isDone;
        public string Title { get; set; }
        //private string deadline;
        public int Id { get; set; }
        public DateTime finishedTime = DateTime.Now;

        //konstruktor
        public TodoItem() //Skriver ut nya uppgifter som ej gjorda
        {
            this.Title = title;
            this.isDone = false;
            //this.deadline = " | Deadline : ";
        }

        public string IsDoneDisplay()
        {

            if (isDone == true)
            {
                return $"[X] {finishedTime}";
            }
            else
                return "[ ]";
        }
    }
}