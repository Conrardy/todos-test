import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { bootstrapApplication } from "@angular/platform-browser";

@Component({
  selector: "app-root",
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  tasks: { name: string; completed: boolean }[] = [];
  newTask: string = "";
  fetchedTodo: { name: string; completed: boolean } | null = null;
  todoName: string = "";

  addTask() {
    if (this.newTask.trim()) {
      this.tasks.push({ name: this.newTask, completed: false });

      fetch("http://localhost:5198/todos", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ name: this.newTask, completed: false }),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("Network response was not ok");
          }
          return response.json();
        })
        .then((data) => {
          console.log("Task added:", data);
          this.newTask = "";
        })
        .catch((error) => console.error("Error adding task:", error));
    }
  }

  deleteTask(index: number) {
    this.tasks.splice(index, 1);
  }

  toggleComplete(index: number) {
    this.tasks[index].completed = !this.tasks[index].completed;
  }

  fetchTasks() {
    fetch("http://localhost:5198/todos")
      .then((response) => response.json())
      .then((data) => {
        this.tasks = data;
      })
      .catch((error) => console.error("Error fetching tasks:", error));
  }

  fetchTodo() {
    if (this.todoName.trim()) {
      fetch(`http://localhost:5198/todos/${this.todoName}`)
        .then((response) => {
          if (!response.ok) {
            throw new Error("Todo not found");
          }
          return response.json();
        })
        .then((data) => {
          this.fetchedTodo = data;
        })
        .catch((error) => {
          console.error("Error fetching todo:", error);
          this.fetchedTodo = null;
        });
    }
  }
}

bootstrapApplication(AppComponent).catch((err) => console.error(err));
