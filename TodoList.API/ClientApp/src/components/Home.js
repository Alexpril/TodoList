import React, { Component } from 'react';
import axios from 'axios';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            tasks: [],
            newTask: '',
        };
    }

    componentDidMount() {
        this.fetchTasks();
    }

    fetchTasks = async () => {
        try {
            const response = await axios.get('/api/todo');
            this.setState({ tasks: response.data });
        } catch (error) {
            console.error('Error fetching tasks:', error);
        }
    };

    addTask = async () => {
        const { newTask } = this.state;

        if (newTask.trim() === '') return;

        try {
            const response = await axios.post('/api/todo', {
                description: newTask,
                completed: false,
            });

            this.setState((prevState) => ({
                tasks: [...prevState.tasks, response.data],
                newTask: '',
            }));
        } catch (error) {
            console.error('Error adding task:', error);
        }
    };

    render() {
        const { tasks, newTask } = this.state;

        return (
            <div>
                <h1>Todo List</h1>
                <div>
                    <input
                        type="text"
                        value={newTask}
                        onChange={(e) => this.setState({ newTask: e.target.value })}
                        placeholder="Enter a new task"
                    />
                    <button onClick={this.addTask}>Add Task</button>
                </div>
                <ul>
                    {tasks.map((task) => (
                        <li key={task.id}>{task.description}</li>
                    ))}
                </ul>
            </div>
        );
    }
}