import { TestBed } from '@angular/core/testing';

import { NewspostsApiClientService } from './newsposts-api-client.service';

describe('NewspostsApiClientService', () => {
  let service: NewspostsApiClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NewspostsApiClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
