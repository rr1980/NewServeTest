import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from '../guards/auth.guard';


@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,

  ],
  declarations: [
  ],
  exports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
  ]
})
export class SharedModule {

  constructor() {}

  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        AuthGuard,
      ]
    };
  }
}
