import { Component, OnInit } from '@angular/core';
import { Project } from '@core/models';
import { ProjectService } from '@core/services/project.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-list-project',
  templateUrl: './list-project.component.html',
  styleUrls: ['./list-project.component.css']
})
export class ListProjectComponent implements OnInit {

  loading = false;
  projectList: Project[] = [];
  constructor(private projectService: ProjectService) { }

  ngOnInit(): void {
    this.loading = false;
    this.projectService.getAll().pipe(first()).subscribe(projects=>{
      this.loading = false;
      this.projectList = projects;
    });
    
  }

}
