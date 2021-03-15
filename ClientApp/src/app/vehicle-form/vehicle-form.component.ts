import { VehicleService } from '../services/vehicle.service';
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
  private features;

  constructor(private vehicleService:VehicleService
    
    ) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe((makes:any[]) => {
      this.makes = makes;
    });
    this.vehicleService.getFeatures().subscribe(features=>{
      this.features= features;
      console.log(JSON.stringify(this.features));
    });

  }
  onMakeChanged()
  {
    console.log("Vehicle: " + JSON.stringify(this.vehicle));
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models: [];

  }

}
