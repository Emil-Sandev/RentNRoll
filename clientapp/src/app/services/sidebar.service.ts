import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {
  private isSidebarOpenSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isSidebarOpen$: Observable<boolean> = this.isSidebarOpenSubject.asObservable();

  constructor() { }

  toggleSidebar() {
    const currentStatus = this.isSidebarOpenSubject.getValue();
    console.log(`current: ${currentStatus}`);
    console.log(`changed: ${!currentStatus}`);
    this.isSidebarOpenSubject.next(!currentStatus);
  }
}
