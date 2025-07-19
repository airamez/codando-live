# Third-Party UI Components for Angular

* Third-party UI component libraries enhance Angular applications by providing pre-built, customizable, and responsive components for faster development.
* They often include features like theming, accessibility, and integration with Angular's ecosystem.
* While Angular Material is the official library from the Angular team (not strictly third-party), others like PrimeNG, Kendo UI, and Syncfusion are developed by external vendors or communities.
* Key considerations:
  * **Compatibility**: Ensure libraries support the latest Angular version (e.g., Angular 18+).
  * **Customization**: Most offer theming and extensibility.
  * **Licensing**: Open-source (free) vs. commercial (paid with support).

## Angular Material

* **Description**: Official Google-backed library implementing Material Design for Angular (free, open-source under MIT).
* **Key Features**: 50+ components like Buttons, Cards, Tables, Dialogs, Datepickers; CDK (Component Dev Kit) for custom builds; theming with palettes.
* **Pros**: Seamless Angular integration; accessible (ARIA-compliant); lightweight; extensive docs and schematics for setup.
* **Cons**: Limited to Material Design style (less flexible for non-Material UIs); fewer advanced enterprise features compared to paid options.
* **Best For**: Apps following Material Design; quick prototyping with official support.
* **Website**: [Material.angular.io](https://material.angular.io)

## PrimeNG

* **Description**: Open-source (MIT license) library with 80+ rich UI components for enterprise-grade apps.
* **Key Features**: DataTable, Charts, Forms, Calendar, Dialogs; theme designer with 280+ UI blocks; Tailwind CSS integration; responsive and touch-optimized.
* **Pros**: Highly customizable; excellent documentation with live demos; free templates; strong community support.
* **Cons**: Feature-dense (can be overwhelming); occasional bugs in complex components like tables.
* **Best For**: Data-heavy applications needing broad component coverage.
* **Website**: [PrimeNG.org](https://primeng.org)

## Kendo UI for Angular

* **Description**: Commercial library from Telerik with 110+ professional components.
* **Key Features**: Grids, Charts, Schedulers, advanced data visualizations; themes for Material/Bootstrap; enterprise support and CLI tools.
* **Pros**: High-performance for large datasets; dedicated support; customizable themes; real-time updates.
* **Cons**: Requires paid license (not free); can be expensive for small projects.
* **Best For**: Data-driven enterprise apps requiring robust support and scalability.
* **Website**: [Telerik.com/kendo-angular-ui](https://www.telerik.com/kendo-angular-ui)

## Syncfusion Angular UI

* **Description**: Comprehensive library with 90+ components; offers free community edition and paid plans.
* **Key Features**: DataGrid, Charts, Scheduler, Forms; supports themes (Material 3, Bootstrap 5, Tailwind CSS); localization and adaptive rendering.
* **Pros**: Enterprise-grade; lightweight with tree-shaking; touch-friendly; free for small teams via community license.
* **Cons**: Advanced features may require paid upgrades; steeper learning curve for full suite.
* **Best For**: Versatile apps needing high customization and performance.
* **Website**: [Syncfusion.com/angular-components](https://www.syncfusion.com/angular-components)

## Recommendations

* Start with Angular Material for simplicity and no cost.
* Use PrimeNG for free, feature-rich open-source needs.
* Opt for Kendo UI or Syncfusion for commercial projects with support.
* Always review docs for Angular version compatibility and test in a prototype.

## Using PrimeNG

* Installation: [](https://primeng.org/installation)

  * Update Angular

  ```shell
  ng update @angular/cli
  ```

  ```shell
  npm install primeng @primeuix/themes
  ```

* Add provider to `app.config.js`

  ```typescript
  import { ApplicationConfig } from '@angular/core';
  import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
  import { providePrimeNG } from 'primeng/config';
  import Aura from '@primeuix/themes/aura';

  export const appConfig: ApplicationConfig = {
      providers: [
          provideAnimationsAsync(),
          providePrimeNG({
              theme: {
                  preset: Aura
              }
          })
      ]
  };
  ```

* Verify

  ```html
  <p-button label="Check" />
  ```

  ```typescript
  import { Component } from '@angular/core';
  import { ButtonModule } from 'primeng/button';

  @Component({
      selector: 'button-demo',
      templateUrl: './button-demo.html',
      imports: [ButtonModule]
  })
  export class ButtonDemo {}
  ```
