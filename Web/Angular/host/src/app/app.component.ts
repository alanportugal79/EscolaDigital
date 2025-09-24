import { Component, ComponentRef, OnDestroy, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { MicroFrontendService } from './micro-frontend.service';

@Component({
  selector: 'app-root',  
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, OnDestroy {
  
  @ViewChild('mfe1', {read: ViewContainerRef, static: true}) mfe1!: ViewContainerRef;
  
  private listComponentRef: ComponentRef<any> | null = null;

  constructor(private microfrontendService: MicroFrontendService) {}

  async ngOnInit() {
    try {
      const listModule = await this.microfrontendService.loadRemoteComponent(4201, 'mfe1');
      this.mfe1.clear();
      this.listComponentRef = this.mfe1.createComponent(listModule.AppComponent);
      this.listComponentRef.changeDetectorRef.detectChanges();
    } catch (error) {
      console.error("Failed to load remote component", error);
    }
  }

  ngOnDestroy(): void {
    if (this.listComponentRef) {
      this.listComponentRef.destroy();
    }
  }
}
