import { UploadFileService } from './services/upload-file.service';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ToFormData } from './services/to-form-data';
import { fileURLToPath } from 'url';
import { FileItem } from './model/file-item';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  form!: FormGroup;
  title = 'FileUpload.Web';
  selectedFile: any = null;
  responseStr?: string;
  responseErr?: string;

  constructor(
    private formBuilder: FormBuilder,
    private uploadFileService: UploadFileService
  ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      file: new FormControl(null, Validators.required),
      email: new FormControl('', [Validators.email, Validators.required]),
      senderName: new FormControl('', Validators.required),
    });
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0] ?? null;
    this.form.patchValue({ file: this.selectedFile });
    this.f['file'].markAsDirty();
  }

  get f() {
    return this.form.controls;
  }
  submit() {
    if (this.form.invalid) {
      return;
    }

    this.uploadFileService
      .uploadFile(ToFormData.createFormData(this.form.value))
      .subscribe(
        (result) => {
          this.responseStr = JSON.stringify(result.files, null, 4);
        },
        (err) => {
          if (err.error) this.responseErr = err.error.title;
        }
      );
  }
}
