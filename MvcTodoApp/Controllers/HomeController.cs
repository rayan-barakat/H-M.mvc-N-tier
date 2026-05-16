using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;
using System.Collections.Generic;
using System.Linq;
namespace MvcTodoApp.Controllers
{
    public class HomeController : Controller
    {
        //قائمة محاكاة لقاعدة البيانات (في الذاكرة)
        private static List<TaskItem> tasks = new List<TaskItem>
{
new TaskItem { Id = 1, Title = "على تدرب MVC Design Pattern", IsComplete = false },
new TaskItem { Id = 2, Title = "على تدرب N-tier Architecture", IsComplete = false },
new TaskItem { Id = 3, Title = "استخدام على تدرب git", IsComplete = false },
};


        /// <summary>
        ///.يعرض القائمة الرئيسية للمهام 
        /// </summary>
        public IActionResult Index()
        {
            return View(tasks);
        }


        /// <summary>
        ///.إضافة مهمة جديدة 
        /// </summary>
        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                int newId = tasks.Max(t => t.Id) + 1;
                var newTask = new TaskItem { Id = newId, Title = title, IsComplete = false };
                tasks.Add(newTask);
            }
            return RedirectToAction("Index");
        }


        /// <summary>
        ///.تعيين مهمة كمكتملة 
        /// </summary>
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                task.IsComplete = true;
            return RedirectToAction("Index");
        }
        /// <summary>

        ///.تعديل عنوان المهمة 
        /// </summary>
        /// <param name="id"> المهمة معرف>/param>
        /// <param name="newTitle">الجديد العنوان>/param>
        [HttpPost]
        public IActionResult EditTask(int id, string newTitle)
        {
            //id ابحث عن المهمة باستخدام :TODO 
            var task = tasks.FirstOrDefault(t => t.Id == id);

            //  غير فارغ  newTitle تأكد من أن المهمة موجودة وأن :TODO
            if (task != null && !string.IsNullOrEmpty(newTitle))
            {
                //عدّل عنوان المهمة :TODO 
                task.Title = newTitle;
            }

            return RedirectToAction("Index");
        }

        ///.تعديل عنوان المهمة 
        /// </summary>
        /// <param name="id"> المهمة معرف</param>
        /// <param name="newTitle">حذف مهمة</param>
        [HttpPost]
        public IActionResult DeleteTask(int id, string newTitle)
        {
            //id ابحث عن المهمة باستخدام :TODO 
            var task = tasks.FirstOrDefault(t => t.Id == id);

            // تأكد من أن المهمة موجودة  :TODO
            if (task != null)
            {
                //TODO: احذف المهمة
                tasks.Remove(task);
            }
             return RedirectToAction("Index");

        }
    }
}