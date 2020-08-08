import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MessageListener } from 'src/app/listeners/message.listener';
import { PersonPhoneService } from 'src/app/services/person-phone.service';

@Component({
    selector: 'app-edit',
    templateUrl: './edit.component.html',
    styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

    title = 'Update Person Phone';
    angForm: FormGroup;
    personPhone: any = {};
    constructor(private route: ActivatedRoute,
        private router: Router,
        private service: PersonPhoneService,
        private fb: FormBuilder,
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

    update(bid, number, tid) {
        this.route.params.subscribe(params => {
            this.service.updatePersonPhone(params['bid'],
                params['number'], params['tid'], bid, number, tid).subscribe(res => {
                    this.listener.infoType = "updated";
                    this.listener.messageSubject.next(res);
                    this.router.navigate(['']);
                });
        });
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.personPhone.businessEntityID = params["bid"];
            this.personPhone.phoneNumber = params["number"];
            this.personPhone.phoneNumberTypeID = params["tid"];
        });
    }
}