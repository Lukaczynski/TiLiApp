import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '@modules/login/login/login.component';
import { AuthGuard } from '@core/guard';
import { ListProjectComponent } from '@modules/project/list-project/list-project.component';
import { Role } from '@core/models';
import { HomeComponent } from '@modules/home/home/home.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'project',
    component: ListProjectComponent,
    canActivate: [AuthGuard],
    //data: { roles: [Role.Admin] }
  },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
