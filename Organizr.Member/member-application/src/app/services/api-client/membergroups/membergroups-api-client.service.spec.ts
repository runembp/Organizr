import { TestBed } from '@angular/core/testing';

import { MembergroupsApiClientService } from './membergroups-api-client.service';

describe('MembergroupsApiClientService', () => {
  let service: MembergroupsApiClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MembergroupsApiClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
