import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryService, PagingCollection, Province } from '../shared/services/country.service';
import { UserService, IUserParams } from '../shared/services/user.service';


@Component({
  selector: 'app-multi-step-registration-form',
  templateUrl: './multi-step-registration-form.component.html',
  styleUrl: './multi-step-registration-form.component.css',
})
export class MultiStepRegistrationFormComponent implements OnInit {

  public countries: PagingCollection | undefined | null;
  public provinces: Province[] = [];

  registerForm: FormGroup;
  countryForm: FormGroup;

  submittedFirstStep = false;
  submittedSecondStep = false;
  currentStep: number = 1;

  selecterProvinceText = "Please select country first"
  resultOfCreationUser = ""

  constructor(private formBuilder: FormBuilder, private countryService: CountryService, private userService: UserService) {
    this.registerForm = this.formBuilder.group(
      {
        login: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.pattern(/^(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{2,}$/)]],
        confirmPassword: ['', [Validators.required]],
        agreementToWorkForFood: [false, [Validators.requiredTrue]],
      },
      {
        validator: this.ConfirmedValidator('password', 'confirmPassword'),
      });

    this.countryForm = this.formBuilder.group(
      {
        countryId: ['', Validators.required],
        provinceId: ['', Validators.required],
      });
  }

  ngOnInit() {
    this.getCountries();
  }

  onGoSecondStep() {
    this.submittedFirstStep = true;
    if (this.registerForm.invalid) {
      return;
    }
    this.currentStep = 2;
  }

  onSubmit() {
    this.submittedSecondStep = true;

    if (this.registerForm.invalid || this.countryForm.invalid) {
        return;
    }

    const userParams: IUserParams = {
      login: this.registerForm.controls['login'].value,
      password: this.registerForm.controls['password'].value,
      countryId: this.countryForm.controls['countryId'].value,
      provinceId: this.countryForm.controls['provinceId'].value
    };

    this.userService.addUser(userParams).subscribe(
      (result) => {
        this.resultOfCreationUser = `User with id ${ String(result) } has been created`;
      },
      (error) => {
        this.resultOfCreationUser = String(error.error.errorMessage);
      }
    );
  }
  get f() {
    return this.registerForm.controls;
  }

  get cf() {
    return this.countryForm.controls;
  }

  get countryInvalid() {
    return this.countryForm.controls['countryId'].value == '';
  }

  get provinceInvalid() {
    return this.countryForm.controls['provinceId'].value == '';
  }

  getCountries() {
    this.countryService.getCountries().subscribe(
      (result) => {
        this.countries = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getProvinces() {
    this.countryService.getProvinces(this.countryForm.controls['countryId'].value).subscribe(
      (result) => {
        this.provinces = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onCountryChange(value: any): void {
    if (this.countryForm.controls['countryId'].value != 0) {
      this.getProvinces();
      this.selecterProvinceText = "Please select province";
    }
  }

  ConfirmedValidator(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];
      if (
        matchingControl.errors &&
        !matchingControl.errors.confirmedValidator
      ) {
        return;
      }
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ confirmedValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }
}
