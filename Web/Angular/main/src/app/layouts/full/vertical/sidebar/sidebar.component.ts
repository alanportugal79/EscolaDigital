import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TablerIconsModule } from 'angular-tabler-icons';
import { MaterialModule } from 'src/app/material.module';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { routes } from 'src/app/services/routes';

@Component({
  selector: 'app-sidebar',
  imports: [TablerIconsModule, MaterialModule],
  templateUrl: './sidebar.component.html',
})
export class SidebarComponent implements OnInit {
  @Input() showToggle = true;
  @Output() toggleMobileNav = new EventEmitter<void>();
  @Output() toggleCollapsed = new EventEmitter<void>();

  userId: string | undefined = "";
  fullName: string | undefined = "";
  email: string | undefined = "";
  
  constructor(
    private authenticationService: AuthenticationService
  ) {
    this.userId = authenticationService.userId;
    this.fullName = authenticationService.fullName;
    this.email = authenticationService.email;
  }

  profilePhotoUrl() : string {
      if (!this.userId) {
        return "/assets/images/profile/user-1.jpg";
      }
  
      return `${routes.session.getCurrentUserPhotoThumbnail}/${this.userId}.jpg`
    }
  

  ngOnInit(): void {}
}
