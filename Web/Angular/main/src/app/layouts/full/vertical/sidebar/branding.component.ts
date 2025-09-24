import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CoreService } from 'src/app/services/core.service';

@Component({
  selector: 'app-branding',
  standalone: true,
  imports: [RouterModule],
  template: `
    <div class="branding d-none d-lg-flex align-items-center">
      <a [routerLink]="['/']" class="d-flex" style="text-decoration:none;">
        <img
          width="42px"
          src="./assets/images/logos/logo-claro.png"
          class="align-middle m-2"
          alt="logo"
        />
        <span style="color:#fff; margin-top:10px; margin-left:3px;"><b>Escola</b> Digital</span>
      </a>
    </div>
  `,
})
export class BrandingComponent {
  options = this.settings.getOptions();

  constructor(private settings: CoreService) {}
}
