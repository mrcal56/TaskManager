
# Task Manager

A simple task manager application developed in C# using Windows Forms. This application allows you to add, check, and delete tasks. Tasks are saved to a `tasks.txt` file located in the user's Documents folder.

## Features

- **Add Tasks:** Add new tasks to your list.
- **Check Tasks:** Mark tasks as completed by checking the checkbox next to each task.
- **Delete Tasks:** Delete tasks from the list using the delete button next to each task.
- **Persistent Storage:** Tasks are saved in a `tasks.txt` file in the Documents folder, so they persist between sessions.

## Screenshots

*Include screenshots of the application here.*

## Installation

### Download the Installer

You can download the installer from the following link:

[Download Task Manager Installer](https://www.mediafire.com/file/x1lk8mgfozu2rm3/TaskManagerSetup.msi/file)

### Prerequisites

- Windows OS
- .NET Framework 4.8 or later

### Installing the Application

1. **Download the Installer:**
   - Click the link above to download the installer (`TaskManagerSetup.msi`).

2. **Run the Installer:**
   - Double-click `TaskManagerSetup.msi` to install the application.

3. **Access the Application:**
   - Once installed, you can find the application in the Start menu.

## Usage

- **Adding a Task:** Type your task into the input box and click "Add Task".
- **Marking a Task as Completed:** Click the checkbox next to a task to mark it as completed. Completed tasks will change color.
- **Deleting a Task:** Click the "Delete" button next to the task to remove it from the list.

## Customization

- **Change Storage Location:** By default, tasks are saved to `tasks.txt` in the Documents folder. You can change this location by modifying the `filePath` variable in `Form1.cs`.

---

