import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StartRoutingModule, routedComponents } from './start-routing.module';
import { SharedModule } from '../../shared-module/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    StartRoutingModule
  ],
  declarations: [routedComponents]
})
export class StartModule { }
