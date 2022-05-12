import { TestBed } from '@angular/core/testing';

import { ConfigurationConstantsService } from './configuration-constants.service';

describe('ConfigurationConstantsService', () => {
  let service: ConfigurationConstantsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConfigurationConstantsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
