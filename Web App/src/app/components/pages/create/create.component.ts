import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageListener } from 'src/app/listeners/message.listener';
import { PersonPhoneService } from 'src/app/services/person-phone.service';

@Component({
    selector: 'app-create',
    templateUrl: './create.component.html',
    styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

    title = 'Add Person Phone';
    angForm: FormGroup;

    constructor(private service: PersonPhoneService,
        private fb: FormBuilder, private router: Router,
        private listener: MessageListener) {
        this.createForm();
    }

    createForm() {
        this.angForm = this.fb.group({
            businessEntityID: ['', Validators.required],
            phoneNumber: ['', Validators.required],
            phoneNumberTypeID: ['', Validators.required]
        });
    }

    add(bid, number, tid) {
        this.service.addPeronPhone(bid, number, tid).subscribe(res => {
            this.router.navigate(['']);
            this.listener.infoType = "add";
            this.listener.messageSubject.next(res);
        }, error => {
            this.router.navigate(['']);
        });
    }

    ngOnInit() {
    }

}