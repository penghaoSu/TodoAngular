import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

import { Observable } from 'rxjs';


@Component({
    selector: 'todo',
    templateUrl: './todo.component.html'
})
export class TodoComponent {

    inputHint = 'What needs to be done?';

    //todos: any[] = [];
    todos: TodoList[];
    todo = '';
    filterType = 'All';
    toggleAll = false;
    private requestOptions = new RequestOptions(
        //{
        //    headers: new Headers({
        //        'authorization': '98e841f0-1023-4217-add0-e1d4244eca40',
        //        'Content-Type': 'application/json'
        //    })
        //}
    );
    public todolist: TodoList[];

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) {
        http.get(originUrl + '/api/todo').subscribe(result => {
            this.todos = result.json() as TodoList[];
        });
    }

    /*
    ngOnInut() {
        this.http.get('/api/todo').map(res => res.json())
            .subscribe((obj) => {
                this.todos = obj;
            })
        //this.getTodos().subscribe(data => {
        //    this.todos = data;
        //});
    }*/

    // 從api取資料
    //getTodos() {
    //  return this.http.get('/api/todo').map(res => {
    //     return res.json();
    //}).catch(error => {
    //    console.log(error);
    //    return Observable.of<any[]>([]);
    //})
    ////return this.http.get('/api/todo', this.requestOptions).map(res => {
    //    return res.json();
    //}).catch(error => {
    //    console.log(error);
    //    return Observable.of<any[]>([]);
    //    })
    //}

    // 呼叫api存資料
    saveTodos(newTodos: TodoList[]) {
        let body = JSON.stringify( newTodos );
        //let headers = new Headers({ 'Content-Type': 'application/json' });
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.originUrl + '/api/todo', body, options).map(res => {
            this.todos = res.json();
        }).catch(error => {
            console.log(error);
            return Observable.of<TodoList[]>([]);
        })
    }

    // 新增
    addTodo() {
        let newTodos = [...this.todos];

        //this.todos.push({
        //    text: this.todo,
        //    done: false
        //});

        newTodos.push({
            text: this.todo,
            done: false
        });
        
        this.saveTodos(newTodos).subscribe(data => {
            this.todo = '';
        });

        //return this.http.post('api/todo', newTodos).map(res => {
        //    this.todos = res.json();
        //}).catch(error => {
        //    console.log(error);
        //    return Observable.of<any[]>([]);
        //})

    }

    // 清除
    clearComplated() {
        let newTodos = this.todos.filter(item => { return !item.done });
        this.saveTodos(newTodos).subscribe(data => { });
    }

    filterTypeChanged(filterType: string) {
        this.filterType = filterType;
    }
    // 全選
    toggleAllChange(value: boolean) {
        let newTodos = [...this.todos];
        newTodos.forEach(item => {
            item.done = value
        });
        this.saveTodos(newTodos).subscribe(data => { });
    }
    // 更新
    updateToggleAllState() {
        this.toggleAll = this.todos.filter(item => { return !item.done; }).length === 0;
        this.saveTodos(this.todos).subscribe(data => { });
    }
    // 移除
    removeTodo(todo) {
        let newTodos = [...this.todos];
        newTodos.splice(this.todos.indexOf(todo), 1);
        this.saveTodos(newTodos).subscribe(data => { });
    }
}

interface TodoList {
    text: string;
    done: boolean;
}

