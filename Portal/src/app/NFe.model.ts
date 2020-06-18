import { PoDateTimeModule } from '@po-ui/ng-components';

export interface NFe {
    documentId: string;
    entidadeId: string;
    ambiente: number;
    modalidade: number;
    dataRecepcao: PoDateTimeModule;
    statusDistribuicao: number;
    correlationId: string;
    //xml: string;
    status: number;
}
