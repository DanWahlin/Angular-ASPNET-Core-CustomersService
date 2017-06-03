import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { ICustomer } from '../shared/interfaces';
import { Sorter } from '../core/sorter';
import { TrackByService } from '../core/trackby.service';

@Component({ 
  moduleId: module.id,
  selector: 'customers-grid', 
  templateUrl: './customers-grid.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush 
})
export class CustomersGridComponent implements OnInit {



  constructor(private sorter: Sorter, public trackby: TrackByService) { }
   
  ngOnInit() {

  }

  sort(prop: string) {
      this.sorter.sort(this.customers, prop);
  }

}