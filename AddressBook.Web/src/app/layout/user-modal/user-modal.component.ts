import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User, Address } from 'src/app/model';
import { BaseService } from '../base.service';
import { NotifyService } from 'src/app/shared/notify.service';

@Component({
  selector: 'app-user-modal',
  templateUrl: './user-modal.component.html',
  styleUrls: ['./user-modal.component.sass']
})
export class UserModalComponent implements OnInit {
  user: User;
  address: Address;
  userForm: FormGroup;
  emailRegEx = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/;
  latlongRegEx = /^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$/;
  formErrors = {
    firstname: '',
    lastname: '',
    email: '',
    address: '',
    longtitue: '',
    latitude: ''
  };

  validationMessages = {
    firstname: {
      required: 'Firstname is required',
      minlength: 'Your Firstname must be at least 3 characters'
    },
    lastname: {
      required: 'Lastname is required',
      minlength: 'Your Lastname must be at least 3 characters'
    },
    email: {
      required: 'Email is required',
      pattern: 'Email is not valid'
    },
    address: {
      required: 'Address is required'
    },
    latitude: {
      required: 'Latitude is required',
      pattern: 'Latitude is not valid'
    },
    longtitue: {
      required: 'Longtitue is required',
      pattern: 'Longtitue is not valid'
    }
  };

  constructor(
    private service: BaseService,
    private notify: NotifyService,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
  }

  private createForm() {
    this.userForm = this.fb.group({
      firstname: [null, Validators.compose([Validators.required, Validators.minLength(3)])],
      lastname: [null, Validators.compose([Validators.required, Validators.minLength(3)])],
      email: [null, Validators.compose([Validators.required, Validators.pattern(this.emailRegEx)])],
      address: [null, Validators.required],
      latitude: [null, Validators.compose([Validators.required, Validators.pattern(this.latlongRegEx)])],
      longtitue: [null, Validators.compose([Validators.required, Validators.pattern(this.latlongRegEx)])]

    });
    this.userForm.valueChanges.subscribe(value => this.onValueChanged(value));
    this.onValueChanged();
  }

  onValueChanged(value?: any) {
    if (!this.userForm) { return; }
    const form = this.userForm;
    for (const field in this.formErrors) {
      if (field) {
        this.formErrors[field] = '';
        const control = form.get(field);
        if (value === 'submit') {
          control.markAsDirty();
        }
        if (control && control.dirty && !control.valid) {
          const messages = this.validationMessages[field];
          for (const key in control.errors) {
            if (key) {
              this.formErrors[field] += messages[key] + ' ';
            }
          }
        }
      }
    }
  }

  onSubmit() {
    const model = this.userForm.value;
    this.user.firstname = model.firstname;
    this.user.lastname = model.lastname;
    this.user.email = model.email;

    const addr = new Address();

    addr.address = model.address;
    addr.lat = model.latitude;
    addr.lon = model.longtitue;
    this.user.addresses = [];
    this.user.addresses.push(addr);

    this.insert();
  }

  private insert() {
    this.service.insert<User>(this.user, 'user').subscribe(res => {
      const contacts = this.service.contacts;
      contacts.unshift(res);
      this.service.contacts = contacts;
      this.notify.success('Your insert was successfull');
      this.cancel();
    }, error => {
      this.notify.danger(error);
    });
  }

  cancel() {
    this.user = null;
  }

  open() {
    this.user = new User();
    this.createForm();
  }

}
