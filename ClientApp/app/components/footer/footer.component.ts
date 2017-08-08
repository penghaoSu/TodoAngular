import { Component, Input, Output, EventEmitter} from '@angular/core';

@Component({
    selector: 'app-footer',
    templateUrl: './footer.component.html'
})
export class FooterComponent {

    @Input()
    todos: any[];

    @Output()
    clearComplated = new EventEmitter();

    filterType = 'All';

    @Output()
    filterTypeChanged = new EventEmitter<string>();

    clearBtnOnClick()
    {
        this.clearComplated.emit();
    }

    changeFilterType(filterType: string)
    {
        this.filterType = filterType;
        this.filterTypeChanged.emit(filterType);
    }

}
