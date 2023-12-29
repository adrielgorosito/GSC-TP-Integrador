import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PeopleCRUDComponent } from './people-crud/people-crud.component';
import { ErrorComponent } from './error/error.component';
import { AddUpdatePersonComponent } from './add-update-person/add-update-person.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'people-crud', component: PeopleCRUDComponent },
  { path: 'error-crud', component: ErrorComponent },
  { path: 'add-update-person', component: AddUpdatePersonComponent },
  { path: '**', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [RouterModule],
})
export class AppRoutingModule {}
