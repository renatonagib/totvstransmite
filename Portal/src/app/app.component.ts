import { Component, OnInit } from '@angular/core';

import { PoMenuItem, PoTableColumn } from '@po-ui/ng-components';
import { AppServiceService } from './app-service.service';
import { NFe } from './NFe.model';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(private nfeService: AppServiceService) {
  }
  items: Array<NFe>;

  readonly menus: Array<PoMenuItem> = [
    { label: 'Home', action: this.onClick.bind(this) }
  ];
  showMoreDisabled = false;

  public readonly columns: Array<PoTableColumn> = [
    {
      property: 'documentId',
      type: 'string',
      width: '15%'
    },
    {
      property: 'entidadeId',
      type: 'string',
      width: '15%'
    },
    {
      property: 'ambiente',
      type: 'number',
      width: '5%'
    },
    {
      property: 'modalidade',
      type: 'number',
      width: '5%'
    },
    {
      property: 'dataRecepcao',
      type: 'dateTime',
      width: '10%'
    },
    {
      property: 'statusDistribuicao',
      type: 'number',
      width: '5%'
    },
    {
      property: 'correlationId',
      type: 'string',
      width: '15%'
    },
    {
      property: 'status',
      type: 'number',
      width: '15%'
    }
  ];

  ngOnInit(){
    this.nfeService.NFes().subscribe( (nfes) => { this.items = nfes;} );

  }
  showMore(event){

  }














  private onClick() {
  }

}
