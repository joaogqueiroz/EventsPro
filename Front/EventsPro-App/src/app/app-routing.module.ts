import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventsComponent } from './components/events/events.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SpeakersComponent } from './components/speakers/speakers.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { EventDetailComponent } from './components/events/event-detail/event-detail.component';
import { EventListComponent } from './components/events/event-list/event-list.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';



const routes: Routes = [
  { path: 'events', redirectTo: 'events/list' },
  {
    path: 'events', component: EventsComponent, 
    children: [
      { path: 'detail/:id', component: EventDetailComponent },
      { path: 'detail', component: EventDetailComponent },
      { path: 'list', component: EventListComponent },
    ]
  },
  {
    path: 'user', component: UserComponent, children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
    ]
  },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'speakers', component: SpeakersComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'contacts', component: ContactsComponent },

  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
