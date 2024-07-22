import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import {  MultiStepRegistrationFormComponent } from './multi-step-registration-form.component';

import { MultiStepRegistrationFormRoutingModule } from './multi-step-registration-form-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    MultiStepRegistrationFormComponent
  ],
  imports: [ HttpClientModule,
    MultiStepRegistrationFormRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [MultiStepRegistrationFormComponent]
})
export class MultiStepRegistrationFormModule { }
