import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import {NgxMaskDirective, provideNgxMask} from 'ngx-mask'
import { NgxMaskPipe } from 'ngx-mask'
import { NgxCaptchaModule } from 'ngx-captcha'
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,  FormsModule, NgxMaskDirective,
    NgxMaskPipe, NgxCaptchaModule, ReactiveFormsModule
  ],
  providers: [provideNgxMask()],
  bootstrap: [AppComponent]
})
export class AppModule { }
