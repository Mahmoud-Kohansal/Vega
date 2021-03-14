import { MakeService } from './../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  private makes:any[];
  private models:any[];
  private vehicle:any = {};
  

  constructor(private makeService:MakeService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe((makes:any[]) => {
      this.makes = makes;
    });

  }
  onMakeChanged()
  {
    console.log("Vehicle: " + JSON.stringify(this.vehicle));
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models: [];

  }

}
