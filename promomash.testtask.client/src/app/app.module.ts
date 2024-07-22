import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MultiStepRegistrationFormComponent } from './multi-step-registration-form/multi-step-registration-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {  MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent, MultiStepRegistrationFormComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, MatSelectModule,
    AppRoutingModule, FormsModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
