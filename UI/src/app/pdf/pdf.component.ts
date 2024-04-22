
import { Component, ViewChild, ElementRef,OnInit } from '@angular/core';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { ActivatedRoute } from '@angular/router';
import { MojConfig } from '../moj-config';
import { HttpClient } from '@angular/common/http';
import { Observable, firstValueFrom } from 'rxjs';


@Component({
  selector: 'app-pdf',
  templateUrl: './pdf.component.html',
  styleUrls: ['./pdf.component.css']
})
export class PdfComponent implements OnInit{

    id: any;
  prijem:any;
  pacijent:any;
  ljekar:any;
  nalazi: any[] = [];

 

  constructor(private http: HttpClient,private route: ActivatedRoute,) {
    this.id = this.route.snapshot.params['id'];
  }
  ngOnInit(): void {
    this.getPrijemPacijenta(this.id);
    this.getNalaz(this.id);
   


  }

  @ViewChild('content') content!: ElementRef;

    async getPrijemPacijenta(prijemId: number): Promise<void> {
    try {
      const headers = MojConfig.http_opcije();
      const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/PrijemPacijenta/" + prijemId, headers));
      this.prijem = response;
   
      await this.getPacijent(this.prijem.pacijentId);
      
      await this.getLjekar(this.prijem.nadlezniLjekarId);
      console.log('Podaci o prijemu pacijenta:', this.prijem);
    } catch (error) {
      console.error('Greška pri dobijanju podataka o pacijentu:', error);
    }
  }

  async getPacijent(pacijentId: number): Promise<void> {
    try {
      const headers = MojConfig.http_opcije();
      const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/Pacijent/" + pacijentId, headers));
      this.pacijent = response
    } catch (error) {
      console.error('Greška pri dobijanju podataka o pacijentu:', error);
    }
  }

  async getLjekar(ljekarId: number): Promise<void> {
    try {
      const headers = MojConfig.http_opcije();
      const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/Ljekar/" + ljekarId, headers));
      console.log('Odgovor od getLjekar:', response);
      this.ljekar = response;
    } catch (error) {
      console.error('Greška pri dobijanju podataka o ljekaru:', error);
    }
  }


  async getNalaz(prijemPacijentaId: number): Promise<void> {
    try {
        const headers = MojConfig.http_opcije();
        const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/Nalaz?PrijemPacijentaId=" + prijemPacijentaId, headers));
        if (response && response.length > 0) {
          console.log('Tekstualni opis nalaza:', response[0].tekstualniOpis);
          this.nalazi[prijemPacijentaId] = response[0].tekstualniOpis;
      } else {
          console.error('Nema dostupnih nalaza za prijem s ID-om:', prijemPacijentaId);
          this.nalazi[prijemPacijentaId] = 'Nije uneseno';
      }
      
    } catch (error) {
        console.error('Greška pri dobijanju podataka o nalazu:', error);
        this.nalazi[prijemPacijentaId] = 'Nije uneseno';
    }
}
async getPacijentImePrezime(pacijentId: number): Promise<string> {
  try {
      const headers = MojConfig.http_opcije();
      const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/Pacijent/" + pacijentId, headers));
      return `${response.ime} ${response.prezime}`;
  } catch (error) {
      console.error('Greška pri dobijanju podataka o pacijentu:', error);
      return 'Nepoznato Ime Prezime';
  }
}


public async SavePDF(): Promise<void> {
  if (!this.content) {
      console.error('Element "content" not available.');
      return;
  }
  const pdfButton = document.querySelector('.pdf-button') as HTMLElement | null;
  if (pdfButton) {
      pdfButton.style.display = 'none';
  }

  const content = this.content.nativeElement;

  try {
      const pacijentImePrezime = await this.getPacijentImePrezime(this.pacijent.id);
      const pdfName = `${pacijentImePrezime}_izvjestaj.pdf`;

      html2canvas(content, { scale: 2 }).then((canvas: HTMLCanvasElement) => {
          const pdf = new jsPDF('p', 'mm', 'a4');
          const imgData = canvas.toDataURL('image/jpeg', 1.0); 

          const pdfWidth = pdf.internal.pageSize.getWidth();
          const pdfHeight = pdf.internal.pageSize.getHeight();
          const imgWidth = pdfWidth;
          const imgHeight = (canvas.height * imgWidth) / canvas.width;

          pdf.addImage(imgData, 'JPEG', 0, 0, imgWidth, imgHeight);

          pdf.save(pdfName);
      });
  } catch (error) {
      console.error('Error occurred while generating PDF:', error);
  }
}


}